import { Component, OnInit } from '@angular/core';
import {TweetService} from '../tweet.service';
import {Router} from '@angular/router';
import {Tweet} from '../../../tweet';
import {User} from '../../../user';

@Component({
  selector: 'app-playground',
  templateUrl: './playground.component.html',
  styleUrls: ['./playground.component.css'],
  providers: [TweetService]
})
export class PlaygroundComponent implements OnInit {
  listTweets: string[];
  constructor(private tweetService: TweetService, private router: Router) {
    // this.listTweets = [];
  }

  ngOnInit() {
    this.tweetService.getTweets()
      .subscribe((data: any) => {
        this.listTweets = data as string[];
        console.log(this.listTweets);
      });
  }

}
