import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Injectable()
export class UserService {
  BASE_URL = 'http://localhost:60755/dummy/';
  constructor(private http: HttpClient, private router: Router) {
    }

    getFollowing() {
    return this.http.get(this.BASE_URL + 'GetFollowing/');
    }
    getFollowers() {
    return this.http.get(this.BASE_URL + 'GetFollowers/');
    }

    register(firstName: string, lastName: string, email: string, password: string, contact: string, region: string) {
      return this.http.post(this.BASE_URL + 'SignUp/', {
        Email: email,
        Password: password,
        FirstName: firstName,
        LastName: lastName,
        Contact: contact,
        Region: region,
        Image: 'assets/user.png'
      });
    }
    login(email: string, password: string) {
    return this.http.post(this.BASE_URL + 'Login/', {email: email, password: password});
    }
    logout() {
    return this.http.post(this.BASE_URL + 'Logout/', {});
    }
    followUser(id: number) {
    return this.http.post(this.BASE_URL + 'FollowUser/' + id, {});
    }
    unfollowUser(id: number) {
      return this.http.post(this.BASE_URL + 'Unfollow/' + id, {});
    }
    searchPeople(searchString: string) {
    return this.http.post(this.BASE_URL + 'SearchUser', {searchString: searchString});
    }
}
