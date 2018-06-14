import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { CKEditorModule } from 'ngx-ckeditor';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { CreateInviteComponent } from './components/invites/create-invite/create-invite.component';
import { GetInviteComponent } from './components/invites/get-invite/get-invite.component';
import { ConfigWeddingComponent } from './components/wedding/config-wedding/config-wedding.component';
import { EditEventComponent } from './components/event/edit-event/edit-event.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CreateInviteComponent,
    GetInviteComponent,
    ConfigWeddingComponent,
    EditEventComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    CKEditorModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'invite/create', component: CreateInviteComponent},
      { path: 'wedding', component: ConfigWeddingComponent },
      { path: ':alias', component: GetInviteComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
