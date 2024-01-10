import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { Person, PersonRequest } from './models';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private baseUrl = "https://localhost:7258"
  constructor(@Inject (HttpClient) private http: HttpClient) { }

  async getAllPeople() {
    const url = `${this.baseUrl}/api/quotes/people`;
    return await firstValueFrom(this.http.get<Person[]>(url));
  }

  async getPerson(id: number) {
    const url = `${this.baseUrl}/api/quotes/people/${id}`;
    return await firstValueFrom(this.http.get<Person>(url));
  }

  async createPerson(person: PersonRequest) {
    const url = `${this.baseUrl}/api/quotes/people`;
    return await firstValueFrom(this.http.post<PersonRequest>(url, person));
  }

  async updatePerson(person: Person) {
    const url = `${this.baseUrl}/api/quotes/people/${person.quoteId}`;
    return await firstValueFrom(this.http.put<Person>(url, person));
  }

  async deletePerson(id: number) {
    const url = `${this.baseUrl}/api/quotes/people/${id}`;
    return await firstValueFrom(this.http.delete<Person>(url));
  }
}
