import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {StaffComponent} from "./staff/staff.component";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {PositionComponent} from "./position/position.component";
import {DepartmentComponent} from "./department/department.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    StaffComponent,
    PositionComponent,
    DepartmentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      {path: '', component: StaffComponent, pathMatch: 'full'},
      {path: 'position', component: PositionComponent},
      {path: 'department', component: DepartmentComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
