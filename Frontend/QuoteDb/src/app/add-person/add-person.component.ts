import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { PersonRequest } from '../models';
import { PersonService } from '../person.service';
@Component({
  selector: 'app-add-person',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-person.component.html',
  styleUrl: './add-person.component.css'
})
export class AddPersonComponent {
  constructor(@Inject(PersonService) private service: PersonService) {}

  showError = false;
  showSaved = false;

  personForm = new FormGroup({
    firstName: new FormControl<string>(''),
    lastName: new FormControl<string>(''),
    text: new FormControl<string>('')
  });

 async onSubmit() {
    console.log(this.personForm.value);

    const personRequest = this.personForm.value as PersonRequest;
    try {
      await this.service.createPerson(personRequest);
      this.showSaved = true;
      this.showError = false;
      this.personForm.reset();
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
    
  }
}
