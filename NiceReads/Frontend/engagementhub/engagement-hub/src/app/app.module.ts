import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EFFECTS } from './effects/effects';
import { EmployeeListComponent } from './components/employees/employee-list/employee-list.component';
import { REDUCERS } from './reducers/reducers';
import { EmployeeService } from './services/employee.service';
import { EngagementHubApiService } from './services/engagement-hub-api.service';
import { ApiService } from './utils/ApiService';
import { URLBuilder } from './utils/URLBuilder';
import { SkillListComponent } from './components/skills/skill-list/skill-list.component';
import { SkillService } from './services/skill.service';
import { SkillComponent } from './components/skills/skill/skill.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    SkillListComponent,
    SkillComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    EffectsModule.forRoot(EFFECTS),
    StoreModule.forRoot(REDUCERS)
  ],
  providers: [
    ApiService,
    EmployeeService,
    EngagementHubApiService,
    SkillService,
    URLBuilder
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
