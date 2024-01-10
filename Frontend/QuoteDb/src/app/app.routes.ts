import { Routes } from '@angular/router';
import { AddSongComponent } from './add-song/add-song.component';
import { AddBookComponent } from './add-book/add-book.component';
import { AddMovieComponent } from './add-movie/add-movie.component';
import { AddPersonComponent } from './add-person/add-person.component';

export const routes: Routes = [ { path: "add-song", component: AddSongComponent },
                                { path: "add-book", component: AddBookComponent },
                                { path: "add-movie", component: AddMovieComponent },
                                { path: "add-person", component: AddPersonComponent },
];
