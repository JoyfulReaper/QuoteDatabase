import { Component, Inject, Input } from '@angular/core';
import { MovieService } from '../movie.service';
import { Movie } from '../models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-display-movie',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display-movie.component.html',
  styleUrl: './display-movie.component.css'
})
export class DisplayMovieComponent {
  constructor(@Inject(MovieService) private service: MovieService) {}

  movie: Movie;

  @Input()
  set id(quoteId: number) {
    this.service.getMovie(quoteId).then(movie => this.movie = movie);
  }
}
