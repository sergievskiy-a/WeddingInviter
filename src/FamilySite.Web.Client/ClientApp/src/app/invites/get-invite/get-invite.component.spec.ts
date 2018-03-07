import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetInviteComponent } from './get-invite.component';

describe('GetInviteComponent', () => {
  let component: GetInviteComponent;
  let fixture: ComponentFixture<GetInviteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetInviteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetInviteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
