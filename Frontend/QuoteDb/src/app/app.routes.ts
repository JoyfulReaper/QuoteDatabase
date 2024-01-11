import { Routes } from '@angular/router';
import { AddSongComponent } from './add-song/add-song.component';
import { AddBookComponent } from './add-book/add-book.component';
import { AddMovieComponent } from './add-movie/add-movie.component';
import { AddPersonComponent } from './add-person/add-person.component';
import { MainPageComponent } from './main-page/main-page.component';

export const routes: Routes = [ { path: "", component: MainPageComponent},
                                { path: "add-song", component: AddSongComponent },
                                { path: "add-book", component: AddBookComponent },
                                { path: "add-movie", component: AddMovieComponent },
                                { path: "add-person", component: AddPersonComponent },
];
