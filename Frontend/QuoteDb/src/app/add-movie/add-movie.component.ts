import { Component, Inject } from '@angular/core';
import { MovieRequest } from '../models';
import { MovieService } from '../movie.service';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-movie',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-movie.component.html',
  styleUrl: './add-movie.component.css'
})
export class AddMovieComponent {

  constructor(@Inject(MovieService) private service: MovieService) {}
    
  movieForm = new FormGroup({
    title: new FormControl<string>('', [Validators.required]),
    characterName: new FormControl<string>('', [Validators.required]),
    actor: new FormControl<string | null>(''),
    text: new FormControl<string>('', [Validators.required]),
  });

  showError=false;
  showSaved=false;

  get title() {
    return this.movieForm.get('title')!;
  }

  get characterName() {
    return this.movieForm.get('characterName')!;
  }

  get text() {
    return this.movieForm.get('text')!;
  }

  async onSubmit() {
    console.log(this.movieForm.value);

    const movieRequest = this.movieForm.value as MovieRequest;
    try {
      if(this.movieForm.valid) {
        await this.service.createMovie(movieRequest);
        this.showSaved = true;
        this.showError = false;
        this.movieForm.reset();
      }
      else
        console.log('Form is invalid');
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
  }
}
