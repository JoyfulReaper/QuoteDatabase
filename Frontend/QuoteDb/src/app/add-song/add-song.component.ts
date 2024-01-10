import { Component, Inject } from '@angular/core';
import { Song } from '../models';
import { SongService } from '../song.service';

@Component({
  selector: 'app-add-song',
  standalone: true,
  imports: [],
  templateUrl: './add-song.component.html',
  styleUrl: './add-song.component.css'
})
export class AddSongComponent {

  constructor(@Inject(SongService) private service: SongService) {}

}
