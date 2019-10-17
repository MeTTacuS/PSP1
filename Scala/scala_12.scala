trait BasicScholarship {
  protected def CalculateChanceScholarship (attendancePercent: Double) : Double = {
    if (attendancePercent > 90)
      return 98;
    if (attendancePercent > 50)
      return 40;
    else
      return 20;
  }
}

trait HarshScholarship {
  protected def CalculateChanceScholarship (attendancePercent: Double) : Double = {
    if (attendancePercent > 90)
      return 80;
    if (attendancePercent > 50)
      return 20;
    else
      return 0;
  }
}

trait RegularAttendance {
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

trait LazyAttendance {
  protected def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double = {
    if (isMain)
      return chance;
    else
      return chance / 2;
  }

  protected def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double = {
    var temp = Math.abs(chance - (100 * (0.1 * distractions.length)));
    if (distractions.contains("lazy")) { temp *= 0.9; }
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



abstract class Student {
  private var _isUniversityMainActivity: Boolean = false;
  private var _distractions: List[String] = List();
  private var _attendancePercent: Double = 0;

  def SetDistractions (distractions: List[String]) : Unit = {
    _distractions = distractions;
  }
  def SetMainActivity (value: Boolean) : Unit = {
    _isUniversityMainActivity = value;
  }
  def SetAttendancePercent (value: Double) : Unit = {
    _attendancePercent = value;
  }

  protected def CheckUniqueness (distractions: List[String]) : Boolean;
  protected def ChanceOfAttendance (isMain: Boolean, chance: Double, distractions: List[String]) : Double;
  protected def AdjustIfMainActivity (isMain: Boolean, chance: Double) : Double;
  protected def CalculateChanceScholarship (attendancePercent: Double) : Double;

  def CalculateChanceOfAttendance (): Double = {
    var chance: Double = 100;
    if (CheckUniqueness(_distractions))
        return ChanceOfAttendance(_isUniversityMainActivity, chance, _distractions);
    else
        return -1;
  }

  def CalculateChanceScholarship(): Double = {
    return CalculateChanceScholarship(_attendancePercent);
  }
}

object Test {
  def main(args: Array[String]): Unit = {

    var regularStudent = new Student with RegularAttendance with BasicScholarship;
    val distractions: List[String] = List("is tired", "lazy", "after vacation");
    regularStudent.SetDistractions(distractions);
    regularStudent.SetMainActivity(true);
    regularStudent.SetAttendancePercent(95);

    println("Chance of attendance is " + regularStudent.CalculateChanceOfAttendance());
    println("Chance of normal scholarship is " + regularStudent.CalculateChanceScholarship())
  }
}

















