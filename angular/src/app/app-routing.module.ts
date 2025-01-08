import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArchetypeComponent } from './archetype/archetype.component';
import { ArmorComponent } from './armor/armor.component';
import { CharacterComponent } from './character/character.component';
import { SkillComponent } from './skill/skill.component';
import { SpecialSkillComponent } from './special-skill/special-skill.component';
import { SpecializationComponent } from './specialization/specialization.component';
import { WeaponComponent } from './weapon/weapon.component';
import { WeaponTypeComponent } from './weapon-type/weapon-type.component';

const routes: Routes = [
  { path: 'archetypes', component: ArchetypeComponent },
  { path: 'armors', component: ArmorComponent },
  { path: 'characters', component: CharacterComponent },
  { path: 'skills', component: SkillComponent },
  { path: 'special-skills', component: SpecialSkillComponent },
  { path: 'specializations', component: SpecializationComponent },
  { path: 'weapons', component: WeaponComponent },
  { path: 'weapon-types', component: WeaponTypeComponent },
  { path: '', redirectTo: '/archetypes', pathMatch: 'full' },
  { path: '**', redirectTo: '/archetypes' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
