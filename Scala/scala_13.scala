import org.joda.time.DateTime
import org.joda.time.format._

trait BasicRewardPolicy {
  def CalculateRewardChance (attendancePercent: Double) : Double = {
    if (attendancePercent > 90)
      return 98;
    if (attendancePercent > 50)
      return 40;
    else
      return 20;
  }
}

trait RegularAttendancePolicy {
  def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double = {
    if (isMain)
      return chance;
    else
      return chance / 2;
  }

  def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double = {
    var temp = Math.abs(chance - (100 * (0.1 * distractions.length)));
    return AdjustIfMainActivity(isMain, temp);
  }

  def CheckUniqueness (distractions: List[String]) : Boolean = {
    if (distractions.distinct.size != distractions.size) {
      return false;
    } else {
      return true;
    }
  }
  
  def CalculateChanceOfAttendance (distractions: List[String], isMain: Boolean): Double = {
    var chance: Double = 100;
    if (CheckUniqueness(distractions))
        return ChanceOfAttendance(isMain, chance, distractions);
    else
        return -1;
  }
}

trait YearsInUniversityCalculator {
  def TimeSpentInUniversity (joinedDate: DateTime) : String = {
    val year = DateTime.now.getYear() - joinedDate.getYear();
    if (year == 0) { return "This is his/hers first year in university"; }
    else if (year == 1) { return "This person has spent 1 year in university"; }
    else { return "This person has spent " + year + " years in university"; }
  }
}

class Student {
  private var _joinedDate: DateTime =_;
  var _distractions: List[String] =_;
  var _attendancePercent: Double =_;
  var _isUniversityMainActivity: Boolean = true;

  def set_joinedDate(x: DateTime): Unit = {_joinedDate = x; }
  def get_joinedDate(): DateTime = { return _joinedDate; }
}

class Lecturer {
  private var _joinedDate: DateTime =_;
  var _distractions: List[String] =_;
  var _attendancePercent: Double =_;
  var _isUniversityMainActivity: Boolean = true;

  def set_joinedDate(x: DateTime): Unit = {_joinedDate = x; }
  def get_joinedDate(): DateTime = { return _joinedDate; }
}

class SecurityGuard {
  private var _joinedDate: DateTime =_;
  var _distractions: List[String] =_;
  var _attendancePercent: Double =_;
  var _isUniversityMainActivity: Boolean = true;

  def set_joinedDate(x: DateTime): Unit = {_joinedDate = x; }
  def get_joinedDate(): DateTime = { return _joinedDate; }

  def GetRiskOfBeingFired(): Double = {
    if (_distractions.length == 0) { return 0; }
    else { return _distractions.length * 8; }
  }
}

object Test {
  def main(args: Array[String]): Unit = {
    var stud = new Student with BasicRewardPolicy with RegularAttendancePolicy with YearsInUniversityCalculator;
    var distractions: List[String] = List("is tired", "lazy", "after vacation");
    stud._distractions = distractions;
    stud.set_joinedDate(new DateTime(2017, 9, 9, 0, 0, 0));
    stud._attendancePercent = 95;
    stud._isUniversityMainActivity = true;

    println(stud.CalculateChanceOfAttendance(stud._distractions, stud._isUniversityMainActivity));
    println(stud.CalculateRewardChance(stud._attendancePercent));
    println(stud.TimeSpentInUniversity(stud.get_joinedDate()));

    var guard = new SecurityGuard with BasicRewardPolicy with RegularAttendancePolicy with YearsInUniversityCalculator;
    distractions = List("is tired", "lazy");
    guard._distractions = distractions;
    guard.set_joinedDate(new DateTime(2015, 9, 9, 0, 0, 0));
    guard._attendancePercent = 95;
    guard._isUniversityMainActivity = true;

    println("=============================================")
    println(guard.CalculateChanceOfAttendance(guard._distractions, guard._isUniversityMainActivity));
    println(guard.CalculateRewardChance(guard._attendancePercent));
    println(guard.TimeSpentInUniversity(guard.get_joinedDate()));
    println("Chance of getting fired is " + guard.GetRiskOfBeingFired());
  }
}



















