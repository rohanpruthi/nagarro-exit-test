import { Component, OnInit } from '@angular/core';
import {User} from '../../../user';
import {UserService} from '../user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-following',
  templateUrl: './following.component.html',
  styleUrls: ['./following.component.css'],
  providers: [UserService]
})
export class FollowingComponent implements OnInit {
listFollowing: User[];
  constructor(private userService: UserService, private router: Router) {
    this.listFollowing = [];
  }

  ngOnInit() {
    this.userService.getFollowing()
      .subscribe((data: any) => {
        this.listFollowing = data;
        console.log(this.listFollowing);
      });
  }
}
