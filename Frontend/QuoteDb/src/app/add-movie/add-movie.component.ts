import { Component, Inject } from '@angular/core';
import { MovieRequest } from '../models';
import { MovieService } from '../movie.service';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-movie',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-movie.component.html',
  styleUrl: './add-movie.component.css'
})
export class AddMovieComponent {

  constructor(@Inject(MovieService) private service: MovieService) {}
    
  movieForm = new FormGroup({
    title: new FormControl<string>(''),
    characterName: new FormControl<string>(''),
    text: new FormControl<string>(''),
  });

}
