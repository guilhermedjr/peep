import { ptBR as resource } from '../presentation/resource'

export const getMonthText = (monthNumber: number) => {
  let monthCode = String(monthNumber)
  let monthText: string

  switch (monthCode) {
    case '1':
      monthText = resource.Peep.Publication.Month.January
      break
    case '2':
      monthText = resource.Peep.Publication.Month.February
      break
    case '3':
      monthText = resource.Peep.Publication.Month.March
      break
    case '4':
      monthText = resource.Peep.Publication.Month.April
      break
    case '5':
      monthText = resource.Peep.Publication.Month.May
      break
    case '6':
      monthText = resource.Peep.Publication.Month.June
      break
    case '7':
      monthText = resource.Peep.Publication.Month.July
      break
    case '8':
      monthText = resource.Peep.Publication.Month.August
      break
    case '9':
      monthText = resource.Peep.Publication.Month.September
      break
    case '10':
      monthText = resource.Peep.Publication.Month.October
      break
    case '11':
      monthText = resource.Peep.Publication.Month.November
      break
    case '12':
      monthText = resource.Peep.Publication.Month.December
      break
  }
  return monthText
}

export const fullTimeToSeconds = (time: string) => {
  let t = time.split(':')
  let seconds = +t[0] * 60 * 60 + +t[1] * 60 + +t[2]
  return seconds
}
