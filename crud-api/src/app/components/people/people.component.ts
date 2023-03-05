import { PeopleService } from './../../services/people.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Person } from 'src/app/person/person';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {

  form: any;
  titleForm?: string;
  people?: Person[];
  tableVisibility?: boolean = true;
  formVisibility?: boolean = false;

  constructor(private peopleService: PeopleService) { }

  ngOnInit(): void {
    this.peopleService.getAll().subscribe(result => {
      this.people = result;
    });

  }

  showForm(): void {
    this.tableVisibility = false;
    this.formVisibility = true;
    this.titleForm = 'Nova Pessoa',
      this.form = new FormGroup({
        name: new FormControl(null),
        lastName: new FormControl(null),
        age: new FormControl(null),
        phone: new FormControl(null),
        address: new FormControl(null),
        profession: new FormControl(null),
      });
  }

  showFormEdit(id: number): void {
    this.tableVisibility = false;
    this.formVisibility = true;
    this.peopleService.getById(id).subscribe(result => {
      this.titleForm = `Atualizar ${result.name} ${result.lastName}`;
      this.form = new FormGroup({
        id: new FormControl(result.id),
        name: new FormControl(result.name),
        lastName: new FormControl(result.lastName),
        age: new FormControl(result.age),
        phone: new FormControl(result.phone),
        address: new FormControl(result.address),
        profession: new FormControl(result.profession),
      });
    });
  }

  sendForm(): void {
    const person: Person = this.form.value;

    if (person.id > 0) {
      this.peopleService.updatePerson(person).subscribe(result => {
        this.formVisibility = false;
        this.tableVisibility = true;
        alert('Pessoa atualizada com sucesso');
        this.peopleService.getAll().subscribe(result => {
          this.people = result;
        });
      });
    }
    else {
      this.peopleService.savePerson(person).subscribe((result) => {
        this.formVisibility = false;
        this.tableVisibility = true;
        alert('Pessoa cadastrada com sucesso');
        this.peopleService.getAll().subscribe(result => {
          this.people = result;
        });
      });
    }

  }

  goToBack(): void {
    this.tableVisibility = true;
    this.formVisibility = false;
  }

}
