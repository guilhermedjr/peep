import dayjs from 'dayjs'
import ptBR from '../i18n/locales/pt-br'

const formatDateString = (date: string): string => date.split("-").reverse().join("/")
const splitDate = (date: string): string[] => date.split("-")
const formatTimeString = (time: string): string => time.substring(0, 7)
const splitTime = (time: string): string[] => time.split(":")

const fullTimeToSeconds = (time: string) => {
  let t = time.split(':')
  let seconds = +t[0] * 60 * 60 + +t[1] * 60 + +t[2]
  return seconds
}

const getMonthText = (month: string) => {
  let monthText: string

  switch (month) {
    case '01':
      monthText = ptBR.Peep.Publication.Month.January
      break
    case '02':
      monthText = ptBR.Peep.Publication.Month.February
      break
    case '03':
      monthText = ptBR.Peep.Publication.Month.March
      break
    case '04':
      monthText = ptBR.Peep.Publication.Month.April
      break
    case '05':
    monthText = ptBR.Peep.Publication.Month.May
      break
    case '06':
    monthText = ptBR.Peep.Publication.Month.June
      break
    case '07':
      monthText = ptBR.Peep.Publication.Month.July
      break
    case '08':
      monthText = ptBR.Peep.Publication.Month.August
      break
    case '09':
      monthText = ptBR.Peep.Publication.Month.September
      break
    case '10':
      monthText = ptBR.Peep.Publication.Month.October
      break
    case '11':
      monthText = ptBR.Peep.Publication.Month.November
      break
    case '12':
      monthText = ptBR.Peep.Publication.Month.December
      break
  }
  return monthText
}

export const getDateText = (date: string) => {
  let dateSplit = splitDate(date)
  return `${dateSplit[2]} ${getMonthText(dateSplit[1])} ${dateSplit[0]}`
}


export const formatPeepDateTime = (date: string, time: string): string => {
  let peepDateTime: string
  
  const now = new Date()
  let dayNow: string = String(now.getDate())
  let monthNow: string = String(now.getMonth())
  let yearNow: string = String(now.getFullYear())
  let dateNow: string = `${yearNow}-${monthNow}-${dayNow}`

  let hoursNow: string = String(now.getHours())
  let minutesNow: string = String(now.getMinutes())
  let secondsNow: string = String(now.getSeconds())
  let timeNow: string = `${hoursNow}:${minutesNow}:${secondsNow}`

  let peepDate = date
  let peepTime = formatTimeString(time)

  let dateTimeNow = dayjs(dateNow + 'T' + timeNow)
  let dateTimePeep = dayjs(peepDate + 'T' + peepTime)

  let daysPassed = dateTimeNow.diff(dateTimePeep, 'day')
 
  if (daysPassed >= 7) {
    let dateSplit = splitDate(peepDate)
    if (dateTimeNow.year() == dateTimePeep.year()) {
      peepDateTime = `${dateSplit[2]} ${getMonthText(dateSplit[1])}`
    } else {
      peepDateTime = `${dateSplit[2]} ${getMonthText(dateSplit[1])} ${dateSplit[0]}`
    }
  } else if (daysPassed >= 1) {
     peepDateTime = `${daysPassed}d`
  } else {
     let hoursPassed = dateTimeNow.diff(dateTimePeep, 'hour')
     if (hoursPassed >= 1) {
       peepDateTime = `${hoursPassed}h`
     } else {
       let minutesPassed = dateTimeNow.diff(dateTimePeep, 'minute')
       if (minutesPassed >= 1) {
         peepDateTime = `${minutesPassed}m`
       } else {
          peepDateTime = 'Agora mesmo'
       }
     }
  }
  return peepDateTime
}

export const formatExpandedPeepDateAndTime = (date: string, time: string): string[] => {
  let dateSplit = splitDate(date)
  let dateText = `${dateSplit[2]} ${getMonthText(dateSplit[1])}, ${dateSplit[0]}`
  let timeText = formatTimeString(time).substring(0, 4)
  return [timeText, dateText]
}
