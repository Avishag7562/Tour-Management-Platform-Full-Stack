import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Trip } from 'src/app/classes/trip';
import { User } from 'src/app/classes/user';
import { TripsService } from 'src/app/services/trips.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css']
})
export class PersonalInfoComponent implements OnInit{

  constructor(public userSer: UserService , public tripSer:TripsService, public route :Router) {}
    ngOnInit(): void {
    this.loadUserTrips
    this.cancelReservation

    }
  user:User=new User();
  id:number | undefined 
  showTrips : boolean = false
  CodeChoose:number = -1
  lTrip:Array<Trip> = new Array<Trip>()



  update(){
    this.userSer.getByMailAndPassword(this.userSer.currentUser.Email! , this.userSer.currentUser.EntryPassword!).subscribe(
    s => {
        this.userSer.update(s)
        alert("update succsesfully");
    },
    err => {
        alert("Not update sucssesfully!")
    }
    );
  }


  loadUserTrips(): void {
    debugger
    this.userSer.getAllToUser(this.userSer.currentUser.CodeUser!).subscribe(
      trips => {
        this.lTrip = trips;
        // this.filterByType(); 
      },
      error => {
        console.error("Error loading user trips:", error.message);
        alert("Error loading user trips.");
      }
    );
  }


//   filterByType(id:number)
// {
//     this.CodeChoose = id
// }
showDetails(trip : Trip) {
  this.tripSer.userChoose = trip
  this.route.navigate([`TripDetails`]);
}

  cancelReservation(userId: number): void {
    this.userSer.delete(this.userSer.currentUser.CodeUser!).subscribe(
      success => {
        alert("Reservation canceled successfully");
        // this.loadUserTrips();
      },
      error => {
        console.error("Error canceling reservation:", error.message);
        alert("Error canceling reservation.");
      }
    );
  }



}
