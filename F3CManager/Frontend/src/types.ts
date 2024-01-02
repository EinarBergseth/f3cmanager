export type EventDTO = {
    id: string
    name: string
    startTime: string
    endTime: string
    isOpenForRegistration: boolean
    registrationStartTime: string
    registrationEndTime: string
    ownerId: string
}

export type ManouverDTO = {
    id: string
    name: string
    factor: number
}