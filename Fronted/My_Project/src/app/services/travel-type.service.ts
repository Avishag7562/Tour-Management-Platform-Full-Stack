import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TravelType } from '../classes/travelType';


@Injectable({
  providedIn: 'root'
})
export class TravelTypeService {

  constructor(private http:HttpClient) { }

  getAll():Observable<Array<TravelType>>
  {
    return this.http.get<Array<TravelType>>("https://localhost:7017/api/TravelType/GetAllTypes")
  }
  
}
