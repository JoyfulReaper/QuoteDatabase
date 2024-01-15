import { Routes } from '@angular/router';
import { AddSongComponent } from './add-song/add-song.component';
import { AddBookComponent } from './add-book/add-book.component';
import { AddMovieComponent } from './add-movie/add-movie.component';
import { AddPersonComponent } from './add-person/add-person.component';
import { MainPageComponent } from './main-page/main-page.component';
import { DisplayBookComponent } from './display-book/display-book.component';
import { DisplayMovieComponent } from './display-movie/display-movie.component';
import { DisplayPersonComponent } from './display-person/display-person.component';
import { DisplaySongComponent } from './display-song/display-song.component';

export const routes: Routes = [ { path: "", component: MainPageComponent},
                                { path: "add-song", component: AddSongComponent },
                                { path: "add-book", component: AddBookComponent },
                                { path: "add-movie", component: AddMovieComponent },
                                { path: "add-person", component: AddPersonComponent },
                                { path: "quotes/books/:id", component: DisplayBookComponent },
                                { path: "quotes/movies/:id", component: DisplayMovieComponent },
                                { path: "quotes/people/:id", component: DisplayPersonComponent },
                                { path: "quotes/songs/:id", component: DisplaySongComponent },
];
