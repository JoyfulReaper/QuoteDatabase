import { Component, Inject, Input } from '@angular/core';
import { PersonService } from '../person.service';
import { Person } from '../models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-display-person',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display-person.component.html',
  styleUrl: './display-person.component.css'
})
export class DisplayPersonComponent {
  constructor(@Inject(PersonService) private service: PersonService) {}

  person: Person

  @Input()
  set id(quoteId: number) {
    this.service.getPerson(quoteId).then(person => this.person = person);
  }
}
