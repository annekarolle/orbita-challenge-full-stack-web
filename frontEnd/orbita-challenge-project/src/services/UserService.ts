 
 
import { api, customAxios } from '@/api/api';
import type UserInterface from '@/interface/userInterface';
import type UserUpdateInterface from '@/interface/userUpdateInterface';
 

export const GetAll = async () => {
    return await api.get('/Students'); 
}

export const Post = async (body: UserInterface) => {
    return await customAxios.post('/Students', body); 
}

export const Put = async (ra: string, body : UserUpdateInterface) => {
    return await api.put(`/Students/${ra}`, body);   
}

export const Delete = async (ra: string) => {
    return await api.delete(`/Students/${ra}`); 
}