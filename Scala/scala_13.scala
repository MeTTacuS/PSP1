import org.joda.time.DateTime
import org.joda.time.format._

trait BasicRewardPolicy {
  protected def CalculateRewardChance (attendancePercent: Double) : Double = {
    if (attendancePercent > 90)
      return 98;
    if (attendancePercent > 50)
      return 40;
    else
      return 20;
  }
}

trait RegularAttendancePolicy {
  protected def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double = {
    if (isMain)
      return chance;
    else
      return chance / 2;
  }

  protected def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double = {
    var temp = Math.abs(chance - (100 * (0.1 * distractions.length)));
    return AdjustIfMainActivity(isMain, temp);
  }

  protected def CheckUniqueness (distractions: List[String]) : Boolean = {
    if (distractions.distinct.size != distractions.size) {
      return false;
    } else {
      return true;
    }
  }
}

trait YearsInUniversityCalculator {
  protected def TimeSpentInUniversity (joinedDate: DateTime) : String = {
    val year = DateTime.now.getYear() - joinedDate.getYear();
    if (year == 0) { return "This is his/hers first year in university"; }
    else if (year == 1) { return "This person has spent 1 year in university"; }
    else { return "This person has spent " + year + " years in university"; }
  }
}

abstract class Student {
  private var _joinedDate: DateTime =_;
  private var _distractions: List[String] =_;
  private var _attendancePercent: Double =_;
  private var _isUniversityMainActivity: Boolean = true;

  def set_joinedDate(x: DateTime): Unit = {_joinedDate = x; }
  def get_joinedDate(): DateTime = { return _joinedDate; }
  def set_distractions(x: List[String]): Unit = {_distractions = x; }
  def set_attendancePercent(x: Double): Unit = {_attendancePercent = x; }
  def set_isUniversityMainActivity(x: Boolean): Unit = {_isUniversityMainActivity = x; }

  protected def CalculateRewardChance (attendancePercent: Double) : Double;
  protected def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double
  protected def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double;
  protected def CheckUniqueness (distractions: List[String]) : Boolean;
  protected def TimeSpentInUniversity (joinedDate: DateTime) : String;

  def CalculateChanceOfAttendance (): Double = {
    var chance: Double = 100;
    if (CheckUniqueness(_distractions))
        return ChanceOfAttendance(_isUniversityMainActivity, chance, _distractions);
    else
        return -1;
  }

  def CalculateRewardChance(): Double = {
    return CalculateRewardChance(_attendancePercent);
  }

  def TimeSpentInUniversity(): String = {
    return TimeSpentInUniversity(_joinedDate);
  }
}

abstract class Lecturer {
  private var _joinedDate: DateTime =_;
  private var _distractions: List[String] =_;
  private var _attendancePercent: Double =_;
  private var _isUniversityMainActivity: Boolean = true;

  def set_joinedDate(x: DateTime): Unit = {_joinedDate = x; }
  def get_joinedDate(): DateTime = { return _joinedDate; }
  def set_distractions(x: List[String]): Unit = {_distractions = x; }
  def set_attendancePercent(x: Double): Unit = {_attendancePercent = x; }
  def set_isUniversityMainActivity(x: Boolean): Unit = {_isUniversityMainActivity = x; }

  protected def CalculateRewardChance (attendancePercent: Double) : Double;
  protected def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double
  protected def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double;
  protected def CheckUniqueness (distractions: List[String]) : Boolean;
  protected def TimeSpentInUniversity (joinedDate: DateTime) : String;

  def CalculateChanceOfAttendance (): Double = {
    var chance: Double = 100;
    if (CheckUniqueness(_distractions))
        return ChanceOfAttendance(_isUniversityMainActivity, chance, _distractions);
    else
        return -1;
  }

  def CalculateRewardChance(): Double = {
    return CalculateRewardChance(_attendancePercent);
  }

  def TimeSpentInUniversity(): String = {
    return TimeSpentInUniversity(_joinedDate);
  }
}

abstract class SecurityGuard {
  private var _joinedDate: DateTime =_;
  private var _distractions: List[String] =_;
  private var _attendancePercent: Double =_;
  private var _isUniversityMainActivity: Boolean = true;

  def set_joinedDate(x: DateTime): Unit = {_joinedDate = x; }
  def get_joinedDate(): DateTime = { return _joinedDate; }
  def set_distractions(x: List[String]): Unit = {_distractions = x; }
  def set_attendancePercent(x: Double): Unit = {_attendancePercent = x; }
  def set_isUniversityMainActivity(x: Boolean): Unit = {_isUniversityMainActivity = x; }

  protected def CalculateRewardChance (attendancePercent: Double) : Double;
  protected def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double
  protected def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double;
  protected def CheckUniqueness (distractions: List[String]) : Boolean;
  protected def TimeSpentInUniversity (joinedDate: DateTime) : String;

  def CalculateChanceOfAttendance (): Double = {
    var chance: Double = 100;
    if (CheckUniqueness(_distractions))
        return ChanceOfAttendance(_isUniversityMainActivity, chance, _distractions);
    else
        return -1;
  }

  def CalculateRewardChance(): Double = {
    return CalculateRewardChance(_attendancePercent);
  }

  def TimeSpentInUniversity(): String = {
    return TimeSpentInUniversity(_joinedDate);
  }

  def GetRiskOfBeingFired(): Double = {
    if (_distractions.length == 0) { return 0; }
    else { return _distractions.length * 8; }
  }
}

object Test {
  def main(args: Array[String]): Unit = {
    var stud = new Student with BasicRewardPolicy with RegularAttendancePolicy with YearsInUniversityCalculator;
    var distractions: List[String] = List("is tired", "lazy", "after vacation");
    stud.set_distractions(distractions);
    stud.set_joinedDate(new DateTime(2017, 9, 9, 0, 0, 0));
    stud.set_attendancePercent(95);
    stud.set_isUniversityMainActivity(true);

    println(stud.CalculateChanceOfAttendance());
    println(stud.CalculateRewardChance());
    println(stud.TimeSpentInUniversity());

    var guard = new SecurityGuard with BasicRewardPolicy with RegularAttendancePolicy with YearsInUniversityCalculator;
    distractions = List("is tired", "lazy");
    guard.set_distractions(distractions);
    guard.set_joinedDate(new DateTime(2015, 9, 9, 0, 0, 0));
    guard.set_attendancePercent(95);
    guard.set_isUniversityMainActivity(true);

    println("=============================================")
    println(guard.CalculateChanceOfAttendance());
    println(guard.CalculateRewardChance());
    println(guard.TimeSpentInUniversity());
    println("Chance of getting fired is " + guard.GetRiskOfBeingFired());
  }
}



















