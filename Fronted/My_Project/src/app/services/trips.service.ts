import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Trip } from '../classes/trip';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TripsService {

  constructor(private http:HttpClient) { }

  userChoose:Trip = new Trip()

getAll():Observable<Array<Trip>>
{
  return this.http.get<Array<Trip>>("https://localhost:7017/api/Trip/GetAllTrip")
}

getTripById(id:string):Observable<Trip>
{
  return this.http.get<Trip>("https://localhost:7017/api/Trip/GetTripById/{id}")
}

update(trip:Trip):Observable<boolean>
{
  return this.http.put<boolean>("https://localhost:7017/api/Trip/UpdateTrip",trip)
}
  
}



