import { CityModel } from './../models/city.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PoTableColumn } from '@po-ui/ng-components';

const API = `${environment.API_ADDRESS}/City`;

@Injectable({ providedIn: 'root' })
export class CityService {
  constructor(private httpClient: HttpClient) {}

  public getColumns(): Array<PoTableColumn> {
    return [
      { property: 'cityId', label: 'ID', type: 'string' },
      { property: 'name', label: 'Cidade', type: 'string' },
      { property: 'uf', label: 'UF.', type: 'string' },
    ];
  }

  public getAllASync() {
    return this.httpClient.get<CityModel[]>(`${API}`);
  }

  public getByID(id: number) {
    return this.httpClient.get<CityModel>(`${API}/${id}`);
  }

  public create(person: CityModel) {
    return this.httpClient.post<CityModel>(`${API}`, person);
  }

  public update(person: CityModel) {
    return this.httpClient.put<CityModel>(`${API}`, person);
  }

  public delete(id: number) {
    return this.httpClient.delete<CityModel>(`${API}/${id}`);
  }
}
