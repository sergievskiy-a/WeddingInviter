import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { registerLocaleData } from '@angular/common';
import localeUk from '@angular/common/locales/uk'; registerLocaleData(localeUk);

import { CKEditorModule } from 'ngx-ckeditor';

import { CountdownService } from './services/countdown.service';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { CreateInviteComponent } from './components/invites/create-invite/create-invite.component';
import { GetInviteComponent } from './components/invites/get-invite/get-invite.component';
import { ConfigWeddingComponent } from './components/wedding/config-wedding/config-wedding.component';
import { EditEventComponent } from './components/event/edit-event/edit-event.component';
import { SingleEventComponent } from './components/event/single-event/single-event.component';

registerLocaleData(localeUk);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreateInviteComponent,
    GetInviteComponent,
    ConfigWeddingComponent,
    EditEventComponent,
    SingleEventComponent
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
      { path: ':alias', component: GetInviteComponent }
    ])
  ],
  providers: [
    CountdownService
   ],
  bootstrap: [AppComponent]
})
export class AppModule { }
