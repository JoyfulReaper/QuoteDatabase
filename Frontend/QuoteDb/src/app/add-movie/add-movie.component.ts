import { Component, Inject } from '@angular/core';
import { MovieRequest } from '../models';
import { MovieService } from '../movie.service';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
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
    title: new FormControl<string>(''),
    characterName: new FormControl<string>(''),
    actor: new FormControl<string | null>(''),
    text: new FormControl<string>(''),
  });

  showError=false;
  showSaved=false;

  async onSubmit() {
    console.log(this.movieForm.value);

    const movieRequest = this.movieForm.value as MovieRequest;
    try {
      await this.service.createMovie(movieRequest);
      this.showSaved = true;
      this.showError = false;
      this.movieForm.reset();
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
  }
}
