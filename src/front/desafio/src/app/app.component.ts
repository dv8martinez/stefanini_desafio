import { PersonModel } from './models/person.mode';
import { CityModel } from './models/city.model';
import { PersonService } from './services/person.service';
import { CityService } from './services/city.service';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { PoModalComponent, PoPageAction } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  @ViewChild('mdlCity') mdlCity: PoModalComponent;
  title = 'Desafio Stefanini';

  public readonly actions: Array<PoPageAction> = [
    { label: 'Gerenciar Cidades', action: this.openMdlCity.bind(this), icon: 'po-icon po-icon-exclamation' },
    
  ];
  public isLoading = false;
  public cities: CityModel[] = [];
  public persons: PersonModel[] = [];
  public cityForm: FormGroup;
  public personForm: FormGroup;
  public cityCols: any[] = [];
  public personsCols: any[] = [];

  /**
   *
   */
  constructor(
    private fb: FormBuilder,
    private cityService: CityService,
    private personService: PersonService
  ) {
    this.createCityForm();
    this.createCityForm();
    this.loadCities();
    this.loadPersons();
    this.personsCols = this.personService.getColumns();
    this.cityCols = this.cityService.getColumns();
  }

  private createPersonForm(): void {
    this.personForm = this.fb.group({
      name: [null, Validators.required],
      cpf: [null, Validators.required],
      city: [null, Validators.required],
    });
  }
  private createCityForm(): void {
    this.personForm = this.fb.group({
      name: [null, Validators.required],
      uf: [null, Validators.required],
    });
  }

  private loadPersons() {
    try {
      this.isLoading = true;
      this.personService
        .getAllASync()
        .pipe(
          catchError((err: HttpErrorResponse) => {
            console.error(err);
            this.isLoading = false;            
            return throwError(err);
          })
        )
        .subscribe((res) => {
          this.isLoading = false;
          this.persons = res;
        });
    } catch (error) {
      console.error(error);
    }
  }
  private loadCities() {
    try {
      this.isLoading = true;
      this.cityService
        .getAllASync()
        .pipe(
          catchError((err: HttpErrorResponse) => {
            console.error(err);
            this.isLoading = false;            
            return throwError(err);
          })
        )
        .subscribe((res) => {
          this.isLoading = false;
          this.cities = res;
        });
    } catch (error) {
      console.error(error);
    }
  }

  private openMdlCity(){
    this.mdlCity.open();
  }
}
