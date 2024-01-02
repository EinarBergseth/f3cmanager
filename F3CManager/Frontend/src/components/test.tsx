import { useEffect } from "react"
import { useFetchManouversQuery } from "../features/manouvers"
import Event from "./event"
import { useFetchEventsQuery } from "../features/events"

const Test = () => {
    const {data: manouvers} = useFetchManouversQuery()
    const {data: events} = useFetchEventsQuery()
    useEffect(() => {
        console.log('manouvers: ', manouvers)
    }, [manouvers])
    
    return (<>
            {
            //manouvers ? JSON.stringify(manouvers) : 'empty'
            }
            <Event event={events && events.length > 0 ? events[0] : undefined} />
        </>)
}

export default Test