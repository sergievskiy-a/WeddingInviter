import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { CreateInviteComponent } from './components/invites/create-invite/create-invite.component';
import { GetInviteComponent } from './components/invites/get-invite/get-invite.component';
import { AddConfigComponent } from './components/config/add-config/add-config.component';
import { GetConfigComponent } from './components/config/get-config/get-config.component';
import { ListConfigComponent } from './components/config/list-config/list-config.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CreateInviteComponent,
    GetInviteComponent,
    AddConfigComponent,
    GetConfigComponent,
    ListConfigComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'i/:alias', component: GetInviteComponent },
      { path: 'invite/create', component: CreateInviteComponent},
      { path: 'configs', component: ListConfigComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
