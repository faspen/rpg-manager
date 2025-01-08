import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WeaponTypeComponent } from './weapon-type/weapon-type.component';
import { WeaponComponent } from './weapon/weapon.component';
import { ArchetypeComponent } from './archetype/archetype.component';
import { CharacterComponent } from './character/character.component';
import { SkillComponent } from './skill/skill.component';
import { SpecializationComponent } from './specialization/specialization.component';
import { SpecialSkillComponent } from './special-skill/special-skill.component';
import { ArmorComponent } from './armor/armor.component';

@NgModule({
  declarations: [
    AppComponent,
    WeaponTypeComponent,
    WeaponComponent,
    ArchetypeComponent,
    CharacterComponent,
    SkillComponent,
    SpecializationComponent,
    SpecialSkillComponent,
    ArmorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideClientHydration(withEventReplay())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
