import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
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
    lastName: new FormControl<string>('', [Validators.required]),
    text: new FormControl<string>('', [Validators.required])
  });

  get lastName() {
    return this.personForm.get('lastName')!;
  }

  get text() {
    return this.personForm.get('text')!;
  }

 async onSubmit() {
    console.log(this.personForm.value);

    const personRequest = this.personForm.value as PersonRequest;
    try {
      if (this.personForm.valid) {
      await this.service.createPerson(personRequest);
      this.showSaved = true;
      this.showError = false;
      this.personForm.reset();
      } else 
        console.log('Form is invalid');
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
  }
}
