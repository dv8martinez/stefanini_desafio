import { environment } from './../../environments/environment';
import { PersonModel } from './../models/person.mode';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PoTableColumn } from '@po-ui/ng-components';

const API = `${environment.API_ADDRESS}/Person`;

@Injectable({providedIn: 'root'})
export class PersonService {
  constructor(private httpClient: HttpClient) { }
  
  public getColumns(): Array<PoTableColumn> {
    return [
              
      { property: 'id', label: 'ID', type: 'string' },
      { property: 'name', label: 'Nome.', type: 'string' },
      { property: 'cpf', label: 'CPF', type: 'string' },
      { property: 'age', label: 'Idade.', type: 'number' },
      { property: 'city.name', label: 'Cidade', type: 'string' },
      { property: 'city.uf', label: 'UF.', type: 'string' },
    ];
  }


  public getAllASync(){
    return this.httpClient.get<PersonModel[]>(`${API}`);
  }

  public getByID(id: number){
    return this.httpClient.get<PersonModel>(`${API}/${id}`)
  }

  public create(person: PersonModel){
    return this.httpClient.post<PersonModel>(`${API}`, person)
  }

  public update(person: PersonModel){
    return this.httpClient.put<PersonModel>(`${API}`, person)
  }

  public delete(id: number){
    return this.httpClient.delete<PersonModel>(`${API}/${id}`)
  }



}