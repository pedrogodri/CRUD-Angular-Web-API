import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../person/person';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  url = 'https://localhost:7065/api/Person'

  constructor(private http: HttpClient) { }

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(this.url);
  }

  getById(id: number): Observable<Person> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<Person>(apiUrl);
  }

  savePerson(person: Person): Observable<any> {
    return this.http.post<Person>(this.url, person, httpOptions);
  }

  updatePerson(person: Person): Observable<any> {
    return this.http.put<Person>(this.url, person, httpOptions);
  }

  deletePerson(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
