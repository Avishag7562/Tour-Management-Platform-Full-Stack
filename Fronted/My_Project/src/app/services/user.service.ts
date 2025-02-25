import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../classes/user';
import { Trip } from '../classes/trip';

@Injectable({
  providedIn: 'root'
})
export class UserService {
   currentUser: User = new User()
  manager: boolean = false
  // newUser:User = new User()


  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<User>> {
    return this.http.get<Array<User>>("https://localhost:7017/api/User/GetAllUsers")
  }

  add(u: User): Observable<number> {
    return this.http.post<number>("https://localhost:7017/api/User/AddUser", u)
  }

  getByMailAndPassword(email: string, password: string): Observable<User> {
    return this.http.get<User>(`https://localhost:7017/api/User/GetUserByMailAndPassword/${email}/${password}`)
  }

  getById(userId: number): Observable<User> {
    return this.http.get<User>(`https://localhost:7017/api/User/GetAllTripToUser/${userId}`);
  }
  
  getAllToUser(userId: number): Observable<Array<Trip>> {
    return this.http.get<Array<Trip>>(`https://localhost:7017/api/User/GetUserById/${userId}`);
  }
  // setCurrentUser(user: User): void {
  //   this.currentUser = user;
  // }

  update(u: User): Observable<User> {
    return this.http.get<User>(`https://localhost:7017/api/User/UpdateUser/${u}`);
  }

  delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`  https://localhost:7017/api/User/DeleteUser/${id}`);
  }


}
