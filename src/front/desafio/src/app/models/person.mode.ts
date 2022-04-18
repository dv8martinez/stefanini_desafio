import { CityModel } from './city.model';
export class PersonModel{
  id!: number;
  name!: string;
  cpf!: string;
  age!: number;
  cityId!: number;
  city: CityModel; 

}