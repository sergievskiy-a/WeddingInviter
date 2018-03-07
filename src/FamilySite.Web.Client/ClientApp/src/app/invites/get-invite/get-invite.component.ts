import { Component, OnInit, Inject } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../../models/invite';
import { Guest } from '../../models/guest';

@Component({
  selector: 'app-get-invite',
  templateUrl: './get-invite.component.html',
  styleUrls: ['./get-invite.component.css']
})
export class GetInviteComponent implements OnInit {

  public alias: string;
  public invite: Invite;
  public greeting: string;

  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
       this.alias = params['alias'];
    });

    this.http.get<Invite>('http://localhost:5000/api/invite/' + this.alias).subscribe(result => {
      this.invite = result;
      this.setGreeting(this.invite.guests);
    }, error => console.error(error));
  }

  setGreeting(guests: Guest[]) {
    this.greeting = 'Dear ';

    if (guests.length === 1) {
      this.greeting = this.greeting + guests[0].firstName + '!';
    } else if (guests.length === 2) {
      this.greeting = this.greeting + guests[0].firstName + ' and ' + guests[1].firstName + '!';
    } else {
      for (let _i = 0; _i < guests.length - 1; _i++) {
        this.greeting = this.greeting + guests[_i].firstName + ', ';
      }
      this.greeting = this.greeting + guests[guests.length - 1].firstName + '!';
    }
  }
}
