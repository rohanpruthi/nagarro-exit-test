import { Injectable } from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class TweetService {
  BASE_URL = 'http://localhost:60755/tweets/';
  constructor(private http: HttpClient, private router: Router) {}
  getTweets() {
    return this.http.get(this.BASE_URL);
  }
  postTweet(tweetBody: string) {
    return this.http.post(this.BASE_URL + 'Create/', {tweetBody: tweetBody});
  }
  editTweet(tweetBody: string, id: number) {
    return this.http.post(this.BASE_URL + 'Edit/' + id, {tweetBody: tweetBody});
  }
  deleteTweet(id: number) {
    return this.http.post(this.BASE_URL + 'Delete/' + id, {});
  }
  likeTweet(id: number) {
    return this.http.post(this.BASE_URL + 'CreateLikeDislikeTweet/' + id, {likeDislike: true});
  }
  dislikeTweet(id: number) {
    return this.http.post(this.BASE_URL + 'CreateLikeDislikeTweet/' + id, {likeDislike: false});
  }
  changeReaction(id: number) {
    return this.http.post(this.BASE_URL + 'EditLikeDislikeTweet/' + id, {});
  }
  deleteReaction(id: number) {
    return this.http.post(this.BASE_URL + 'DeleteLikeDislikeTweet/' + id, {});
  }
}
