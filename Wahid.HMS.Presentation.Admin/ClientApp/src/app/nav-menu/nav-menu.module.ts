import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { TopMenuComponent } from './top-menu/top-menu.component';



@NgModule({
  declarations: [SideMenuComponent, TopMenuComponent],
  imports: [
    CommonModule
  ]
})
export class NavMenuModule { }
