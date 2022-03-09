import { SpriteApi } from "./spriteApi.model"

export interface PokeApi {
    id?:number,
    name?:string,
    weight?:number,
    sprites: SpriteApi,
    stats?:
    [
        StatApi,
        StatApi,
        StatApi
    ]
}

export interface StatApi {
    base_stat:number,
    stat: {
        name:string
    }
}
