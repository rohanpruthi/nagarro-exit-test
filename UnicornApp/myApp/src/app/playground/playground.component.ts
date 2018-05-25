import { Component, OnInit } from '@angular/core';
import {TweetService} from '../tweet.service';
import {Router} from '@angular/router';
import {Tweet} from '../../../tweet';
import {User} from '../../../user';
import {subscribeToResult} from 'rxjs/util/subscribeToResult';

@Component({
  selector: 'app-playground',
  templateUrl: './playground.component.html',
  styleUrls: ['./playground.component.css'],
  providers: [TweetService]
})
export class PlaygroundComponent implements OnInit {
  listTweets: any[];
  checkId: number = +sessionStorage.getItem('currentUserId');
  constructor(private tweetService: TweetService, private router: Router) {
     this.listTweets = [];
  }

  ngOnInit() {
    this.tweetService.getTweets()
      .subscribe((data: any) => {
        this.listTweets = data;
        console.log(this.listTweets);
      });
  }
deleteTweet(id: number) {
    this.tweetService.deleteTweet(id)
      .subscribe((data) => {
        // console.log(data);
        this.router.navigateByUrl('/playground');
      });
    this.tweetService.getTweets()
      .subscribe((data: any) => {
      this.listTweets = data;
    });
}
addTweet(tweetBody: string) {
  this.tweetService.postTweet(tweetBody)
    .subscribe((data) => {
      // console.log(data);
      this.router.navigateByUrl('/playground');
    });
  this.tweetService.getTweets()
    .subscribe((data: any) => {
      this.listTweets = data;
    });
}
editTweet(id: number, tweetBody: string) {
    this.tweetService.editTweet(tweetBody, id)
      .subscribe((data: any) => {
        console.log(data);
      });
    this.tweetService.getTweets()
      .subscribe((data: any) => {
        this.listTweets = data;
      });
}
}
