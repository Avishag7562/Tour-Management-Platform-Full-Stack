import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Trip } from 'src/app/classes/trip';
import { TripsService } from 'src/app/services/trips.service';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.css']
})
export class TripDetailsComponent implements OnInit {

constructor(public tripSer:TripsService){}

tripList:Array<Trip>=new Array<Trip>()
bookingPlace:number=0
showBookingDialog: boolean = false

  ngOnInit(): void {
    this.tripSer.getAll().subscribe(
      succ=>{  
       this.tripList = succ
      },
      err=>{
       alert(err.message)
      }
    )
  }


  confirmBooking(trip : Trip)
  {
    if(this.bookingPlace < this.tripSer.userChoose.AvailablePlaces!)
    {
      trip.AvailablePlaces = trip.AvailablePlaces! - this.bookingPlace
      this.tripSer.update(trip).subscribe(
        succsess =>{
          alert('The order has been received')
          this.showBookingDialog = false

        },
        err => {alert(err.message)}
        ); 
    }
    else
    alert('There are not enough places')
  }

  open()
  {
    this.showBookingDialog=true
  }

  closeBookingDialog()
  {
    debugger
    this.showBookingDialog = false
  }
}
