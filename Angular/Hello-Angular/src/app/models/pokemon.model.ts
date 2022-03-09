export interface Pokemon {
    pokeId:number;
    attack:number;
    defense:number;
    health:number;
    speed:number;
    type:string;
    rating:number; //This will range from 1 to 5
    name:string;
    level:number;
    // sprites?: {
    //     front_default:string;
    // };
}