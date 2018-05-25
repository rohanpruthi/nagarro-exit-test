import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
listPeopleSearch: any[];
  constructor(private userService: UserService, private router: Router) {
    this.listPeopleSearch = [];
  }

  ngOnInit() {
  }
searchPeople(searchString: string) {
    this.userService.searchPeople(searchString)
      .subscribe((data: any) => {
        this.listPeopleSearch = data;
        console.log(this.listPeopleSearch);
      });
}
follow(id: number) {
    this.userService.followUser(id)
      .subscribe((data) => {
        // console.log(data);
      });
}
}
