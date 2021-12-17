import useTranslation from './hooks/useTranslation'

export const getMonthText = (monthNumber: number) => {
  const { t } = useTranslation()
  let monthCode = String(monthNumber)
  let monthText: string

  switch (monthCode) {
    case '1':
      monthText = t("Peep.Publication.Month.January")
      break
    case '2':
      monthText = t("Peep.Publication.Month.February")
      break
    case '3':
      monthText = t("Peep.Publication.Month.March")
      break
    case '4':
      monthText = t("Peep.Publication.Month.April")
      break
    case '5':
    monthText = t("Peep.Publication.Month.May")
      break
    case '6':
    monthText = t("Peep.Publication.Month.June")
      break
    case '7':
      monthText = t("Peep.Publication.Month.July")
      break
    case '8':
      monthText = t("Peep.Publication.Month.August")
      break
    case '9':
      monthText = t("Peep.Publication.Month.September")
      break
    case '10':
      monthText = t("Peep.Publication.Month.October")
      break
    case '11':
      monthText = t("Peep.Publication.Month.November")
      break
    case '12':
      monthText = t("Peep.Publication.Month.December")
      break
  }
  return monthText
}

export const fullTimeToSeconds = (time: string) => {
  let t = time.split(':')
  let seconds = +t[0] * 60 * 60 + +t[1] * 60 + +t[2]
  return seconds
}

export const formatDateTime = (date: string, time: string): string => {
  const now = new Date()

  date = date.replace("/", "").replace("-", "").replace("/", "").replace("-", "")

  let day = date.substr(0, 2),
      month = Number(date.substr(2, 2)),
      year = date.substr(6, 2)

  time = time.replace(":", "").replace(":", "")

  let hours = time.substr(0, 2),
      minutes = time.substr(2, 2),
      seconds = time.substr(4, 2)

  let dayNow: string = String(now.getDate())
  let monthNow: string = String(now.getMonth())
  let yearNow: string = String(now.getFullYear()).substr(2, 2)

  let hoursNow: string = String(now.getHours())
  let minutesNow: string = String(now.getMinutes())
  let secondsNow: string = String(now.getSeconds())

  if (year != yearNow)
    return `${day} ${getMonthText(month)} ${year}`

  if (String(month) == monthNow) {
    let daysSincePost = Number(dayNow) - Number(day)

    if (daysSincePost < 7) {
      if (day == dayNow) {
        if (hours == hoursNow || Number(hours) == Number(hoursNow) - 1) {
          let secondsSincePast = fullTimeToSeconds(time)

          if (secondsSincePast < 60) 
            return `${secondsSincePast}s`
          if (secondsSincePast < 3600)
            return `${Math.round(secondsSincePast / 60)}min`
          return '1h'
        } else {
          return `${Number(hoursNow) - Number(hours)}h`
        }
      } else {
          return `${Number(dayNow) - Number(day)}d`
      } 
    } 
     else {
      return `${day} ${getMonthText(month)}`
    }
  }
  else {
    return `${day} ${getMonthText(month)}`
  }

}
