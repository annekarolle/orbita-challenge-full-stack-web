import { api } from "@/api/api";
import type AuthInterface from "@/interface/authInterface";

export const Post = async (body: AuthInterface) => {    
    return await api.post('/Login', body); 
}