import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './comps/home/home.component';
import { RegisterComponent } from './comps/register/register.component';
import { TripsComponent } from './comps/trips/trips.component';
import { TripDetailsComponent } from './comps/trip-details/trip-details.component';
import { UsersComponent } from './comps/users/users.component';
import { PersonalInfoComponent } from './comps/personal-info/personal-info.component';

const routes: Routes = [
  {path:'home',component:HomeComponent},
  {path:'register', component:RegisterComponent},
  {path:'trips', component:TripsComponent},
  {path:'personal-area', component: PersonalInfoComponent},
  {path:'TripDetails', component: TripDetailsComponent},
  {path:'users', component: UsersComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
