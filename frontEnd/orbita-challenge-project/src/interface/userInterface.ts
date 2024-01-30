export default interface UserInterface{
    name: string
    email: string
    ra: string
    cpf: string
}

export default interface UserUpdateRequest {
    id: number
    data: {
      name: string
      email: string
    }
  }