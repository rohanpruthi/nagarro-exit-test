import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {RouterModule, Routes} from '@angular/router';
import {FormsModule} from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { PlaygroundComponent } from './playground/playground.component';
import { FollowersComponent } from './followers/followers.component';
import { FollowingComponent } from './following/following.component';
import { SearchComponent } from './search/search.component';
import { NavbarComponent } from './navbar/navbar.component';
import {UserService} from './user.service';
import {TweetService} from './tweet.service';
import {HttpClientModule} from '@angular/common/http';
import {HttpModule} from '@angular/http';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', redirectTo: 'login', pathMatch: 'full'},
  {path: 'playground', component: PlaygroundComponent},
  {path: 'followers', component: FollowersComponent},
  {path: 'following', component: FollowingComponent},
  {path: 'search', component: SearchComponent}
];
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    PlaygroundComponent,
    FollowersComponent,
    FollowingComponent,
    SearchComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
  ],
  providers: [UserService, TweetService],
  bootstrap: [AppComponent]
})
export class AppModule { }
