import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-following',
  templateUrl: './following.component.html',
  styleUrls: ['./following.component.css'],
  providers: [UserService]
})
export class FollowingComponent implements OnInit {
listFollowing: any[];
  constructor(private userService: UserService, private router: Router) {
    this.listFollowing = [];
  }

  ngOnInit() {
    this.userService.getFollowing()
      .subscribe((data: any) => {
        this.listFollowing = data;
        // console.log(this.listFollowing);
        localStorage.setItem('followingCount', this.listFollowing.length.toString());
      });
  }
  unfollow(id: number) {
    this.userService.unfollowUser(id)
      .subscribe((data: any) => {
        // console.log(data);
        this.router.navigateByUrl('/following');
      });
    this.userService.getFollowing()
      .subscribe((data: any) => {
        this.listFollowing = data;
        // console.log(this.listFollowing);
        localStorage.setItem('followingCount', this.listFollowing.length.toString());
      });
  }
}
