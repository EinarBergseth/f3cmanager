import { useEffect } from "react"
import { useFetchManouversQuery } from "../features/manouvers"

const Test = () => {
    const {data: manouvers} = useFetchManouversQuery()
    useEffect(() => {
        console.log('manouvers: ', manouvers)
    }, [manouvers])
    
    return (<>{manouvers ? JSON.stringify(manouvers) : 'empty'}</>)
}

export default Test