//
//  HealthDataManager.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/10/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import HealthKit
import WatchKit

class HealthDataManager {
    func startHealthTracker() {
        
    }
    
    func stopHealthTracker() {
        
    }
    
    func retrieveHealthData() -> HealthSnapshot? {
        return nil
    }
    // MARK: - Private
    let heartRateType = HKQuantityType.quantityTypeForIdentifier(HKQuantityTypeIdentifierHeartRate)!
    let heartRateUnit = HKUnit(fromString: "count/min")
    var heartRateQuery: HKQuery?
    let healthStore = HKHealthStore()
    
    private func createStreamingHeartRateQuery() -> HKQuery {
        let predicate = HKQuery.predicateForSamplesWithStartDate(NSDate(), endDate: nil, options: .None)
        
        let query = HKAnchoredObjectQuery(type: heartRateType, predicate: predicate, anchor: nil, limit: Int(HKObjectQueryNoLimit)) { (query, samples, deletedObjects, anchor, error) -> Void in
            self.addSamples(samples)
        }
        query.updateHandler = { (query, samples, deletedObjects, anchor, error) -> Void in
            self.addSamples(samples)
        }
        
        return query
    }
    
    private func addSamples(samples: [HKSample]?) {
        guard let samples = samples as? [HKQuantitySample] else { return }
        guard let quantity = samples.last?.quantity else { return }
        print("Heart rate = \(quantity.doubleValueForUnit(heartRateUnit))")
    }
}