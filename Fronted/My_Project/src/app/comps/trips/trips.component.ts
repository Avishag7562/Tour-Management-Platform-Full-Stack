import { Component, OnInit } from '@angular/core';
import { Trip } from '../../classes/trip';
import { TravelType } from '../../classes/travelType';
import { Router } from '@angular/router';
import { TripsService } from 'src/app/services/trips.service';
import { TravelTypeService } from 'src/app/services/travel-type.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent  implements OnInit {
constructor(public tripSer:TripsService, public travelTypeSer:TravelTypeService,public route :Router){}
tripList:Array<Trip> = new Array<Trip>()
travelTypeList:Array<TravelType> = new Array<TravelType>()
newTrip:Trip = new Trip()
CodeChoose:number = -1

ngOnInit() {
  this.tripSer.getAll().subscribe(
    success =>{
      this.tripList = success
    },
    error =>{
      alert(error.message)
    }
  )
  this.travelTypeSer.getAll().subscribe(
    success =>{
      this.travelTypeList = success
    },
    error =>{
      alert(error.message)
    }
  )
}

filterByType(id:number)
{
    this.CodeChoose = id
}
showDetails(trip : Trip) {
  this.tripSer.userChoose = trip
  this.route.navigate([`TripDetails`]);
}

}
